'use strict';
var es = window.es || {};
es.grids = window.es.grids || {};

/**
 * Manages Kendo Grid columns (showing, hiding, resetting column settings, etc.).
**/

es.grids.manageColumn = function (gridId, manageTitle, manageApply, manageReset, clearOption, resetSettingTable, divButtonId) {
    console.log('refaktor',5)
    const grid = $(`#${gridId}`).data("kendoGrid");
    if (!grid) {
        return;
    }

    const manageColumnPopupId = `columnPopup_${gridId}`;
    const formId = `columnsForm_${gridId}`;
    const storageKey = `gridColumnStore_${gridId}`;
    const btnId = `btnColumnManager_${divButtonId}`;
    let $manageColumnBtn= $(`#${btnId}`);


    if ($manageColumnBtn.length === 0) {
        $manageColumnBtn= es.grids.createManageButton(btnId, manageTitle, divButtonId);
    }
    if (!$(`#${manageColumnPopupId}`).length) {
        $("body").append(es.grids.createManageColumnPopupHtml(manageColumnPopupId, formId, manageApply, manageReset, clearOption, resetSettingTable));
    }
    let popup = es.grids.initManageColumnPopup(manageColumnPopupId, btnId);
    const $manageColumnPopup = $(`#${manageColumnPopupId}`);
    const resetWindow = es.grids.initResetDialog("#dialog-reset-table");
    $btn.off("click.columnManager").on("click.columnManager", function () {
        es.grids.handleManageColumnsButtonClick(grid, popup, $btn, storageKey, formId, manageColumnPopupId);
    });
    $manageColumnPopup.find(".resetSettingTable").off("click").on("click", function () {
        resetWindow.center().open();
    });
    $manageColumnPopup.find(".applyColumns").off("click").on("click", function () {
        es.grids.applyColumnSettings(grid, formId, popup, storageKey);
    });
    $manageColumnPopup.find(".resetColumns").off("click").on("click", function () {
        $manageColumnPopup.find("input[type=\"checkbox\"]").prop("checked", true);
    });

    $manageColumnPopup.find(".clearOption").off("click").on("click", function () {
        popup.close();
        if (window.es?.flexSearch?.clearAll) {
            es.flexSearch.clearAll();
        }
        grid.dataSource.filter([]);
        grid.dataSource.read();
    });
    $("#reset-table-confirm").off("click").on("click", function () {
        es.grids.resetGridToDefaults(grid, resetWindow, storageKey);
    });
    $("#reset-table-cancel").off("click").on("click", function () {
        resetWindow.close();
    });
    es.grids.bindPopupScrollHandlers(popup, manageColumnPopupId);
    es.grids.loadColumnSettings(grid, storageKey);
    grid.resize(true);
};

es.grids.createManageButton = function (btnId, manageTitle, divButtonId) {
    const $manageColumnBtn= $("<button>")
        .attr("id", btnId)
        .addClass("k-button k-button-md k-button-solid")
        .html(`<span class="icon-column-edit" style="margin-right:10px;"></span>${manageTitle}`);

    if (divButtonId) {
        const $targetDiv = $(`#${divButtonId}`);
        if ($targetDiv.length) {
            $targetDiv.append($manageColumnBtn);
        }
    }

    return $btn;
};

es.grids.createManageColumnPopupHtml = function (manageColumnPopupId, formId, manageApply, manageReset, clearOption, resetSettingTable) {
    return `
            <div id="${manageColumnPopupId}" class="ecdp-column-manage-popup">
                <form id="${formId}"></form>
                <div class="popup-buttons">
                    <button type="button" class="k-button ecdp-main-button k-input-button applyColumns">${manageApply}</button>
                    <button type="button" class="k-button ecdp-secondary-button k-input-button resetColumns">${manageReset}</button>
                 </div>
                 <div class="manage-column-popup-text clearOption">
                    <span class="icon-filter-clear icon"></span><span>${clearOption}</span>
                </div>
                <div class="manage-column-popup-text resetSettingTable">
                    <span class="icon-refresh icon"></span><span>${resetSettingTable}</span>
                </div>
            </div>`;
};

es.grids.initManageColumnPopup = function (manageColumnPopupId, btnId) {
    const $manageColumnPopupEl = $(`#${manageColumnPopupId}`);
    let popup = $manageColumnPopupEl.data("kendoPopup");

    if (!popup) {
        popup = $manageColumnPopupEl.kendoPopup({
            anchor: "#" + btnId,
            origin: "bottom right",
            position: "top right",
            appendTo: "body",
            collision: "none",
            offset: { top: 6, left: 0 }
        }).data("kendoPopup");
    }
    return popup;
};

es.grids.handleManageColumnsButtonClick = function (grid, popup, $btn, storageKey, formId, manageColumnPopupId) {
    if (!grid) {
        return;
    }
    if (popup.visible && popup.visible()) {
        popup.close();
        return;
    }
    es.grids.buildColumnList(grid, storageKey, formId, manageColumnPopupId);
    popup.open($btn);
};

es.grids.buildColumnList = function (currentGrid, storageKey, formId, manageColumnPopupId) {
    if (!currentGrid) {
        return;
    }
    const form = $(`#${formId}`);
    form.empty();
    const saved = localStorage.getItem(storageKey);
    const savedSettings = saved ? JSON.parse(saved) : {};

    currentGrid.columns.forEach((col, idx) => {
        if (!col.field) {
            return;
        }
        if (col.headerAttributes && col.headerAttributes.skipManage) {
            return;
        }
        const visible = savedSettings[col.field] ? savedSettings[col.field].visible : !col.hidden;
        let title = "";

        if (col.headerTemplate) {
            const div = document.createElement("div");
            div.innerHTML = col.headerTemplate;
            title = div.textContent.trim();
        } else if (col.title) {
            title = col.title;
        } else {
            title = col.field;
        }

        form.append(`
            <div class="k-form-field padding-checkbox">
                <input type="checkbox" class="k-checkbox" id="${manageColumnPopupId}_col_${idx}" data-field="${col.field}" ${visible ? "checked" : ""}>
                <label for="${manageColumnPopupId}_col_${idx}">${title}</label>
            </div>
        `);
    });
};

es.grids.applyColumnSettings = function (grid, formId, popup, storageKey) {
    if (!grid) {
        return
    };
    $("#" + formId + " input[type=checkbox]").each(function () {
        const field = $(this).data("field");
        const isChecked = $(this).is(":checked");
        const col = grid.columns.find(c => c.field === field);
        if (!col) {
            return;
        }
        if (isChecked) {
            grid.showColumn(field);
        } else {
            grid.hideColumn(field);
        }
        const selector = "[data-field=\"" + field + "\"]";
        if (isChecked) {
            grid.thead.find("th" + selector).show();
            grid.tbody.find("td" + selector).show();
        } else {
            grid.thead.find("th" + selector).hide();
            grid.tbody.find("td" + selector).hide();
        }
    });

    es.grids.saveColumnSettings(grid, storageKey);
    popup.close();
    setTimeout(() => {

        grid.table.css("width", "100%");

        const visible = grid.columns.filter(c => !c.hidden);
        const last = visible[visible.length - 1];
        grid.autoFitColumn(last.index);
    }, 10);
};

es.grids.saveColumnSettings = function (currentGrid, storageKey) {
    if (!currentGrid) {
        return;
    }
    const settings = {};
    currentGrid.columns.forEach(col => {
        if (col.field) {
            settings[col.field] = {
                visible: !col.hidden

            };
        }
    });
    localStorage.setItem(storageKey, JSON.stringify(settings));
};

es.grids.initResetDialog = function (selector) {
    const $dlg = $(selector);
    if (!$dlg.data("kendoWindow")) {
        $dlg.kendoWindow({
            modal: true,
            visible: false,
            title: false,
            minWidth: 500,
            maxWidth: 600,
            resizable: false,
            animation: {
                open: { effects: "fade:in", duration: 300 },
                close: { effects: "fade:out", duration: 300 }
            }
        });
    }
    return $dlg.data("kendoWindow");
};

es.grids.resetGridToDefaults = function (grid, resetWindow, storageKey) {
    if (!grid) {
        return;
    }

    resetWindow.close();
    localStorage.removeItem(storageKey);

    if (window.es?.flexSearch?.clearAll) {
        es.flexSearch.clearAll();
    }

    grid.dataSource.filter([]);

    grid.columns.forEach((col, idx) => {
        if (col.hidden) {
            if (col.field) {
                grid.showColumn(col.field);
            } else {
                grid.showColumn(idx);
            }
        }
    });

    grid.dataSource.read();
    grid.refresh();
};

es.grids.bindPopupScrollHandlers = function (popup, manageColumnPopupId) {
    popup.bind("open", () => {
        const $manageColumnPopup = $(`#${manageColumnPopupId}`);
        const $form = $manageColumnPopup.find("form");

        const handler = es.grids.handlePopupScrollClose(popup, $form);

        $manageColumnPopup[0].addEventListener("wheel", handler, { passive: false, capture: true });
        $manageColumnPopup[0].addEventListener("touchmove", handler, { passive: false, capture: true });

        $manageColumnPopup.data("scrollHandler", handler);

        $("html, body").css("overflow", "hidden");
    });

    popup.bind("close", () => {
        const $manageColumnPopup = $(`#${manageColumnPopupId}`);
        const handler = $manageColumnPopup.data("scrollHandler");

        if (handler) {
            $manageColumnPopup[0].removeEventListener("wheel", handler, { capture: true });
            $manageColumnPopup[0].removeEventListener("touchmove", handler, { capture: true });
            $manageColumnPopup.removeData("scrollHandler");
        }

        $("html, body").css("overflow", "");
    });
};


es.grids.handlePopupScrollClose = function (popup, $form) {
    return function (e) {
        const target = e.target;
        if ($form.length && $.contains($form[0], target)) {
            return;
        }
        e.preventDefault();
        popup.close();
    };
};

es.grids.loadColumnSettings = function (currentGrid, storageKey) {
    if (!currentGrid) {
        return;
    }

    const saved = localStorage.getItem(storageKey);
    if (!saved) {
        return;
    }

    const settings = JSON.parse(saved);
    currentGrid.columns.forEach(col => {
        if (!col.field) {
            return;
        }
        const s = settings[col.field];
        if (!s) {
            return;
        }
        if (s.visible === false) {
            currentGrid.hideColumn(col);
        }
        else {
            currentGrid.showColumn(col);
        }
    });
    currentGrid.resize();
};
