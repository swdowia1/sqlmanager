--Urodziny w wybranym dniu

SELECT 
    c.Id,
    c.DateOfBirth,
    day(c.DateOfBirth)
FROM [Customer].[Customer] c WITH (NOLOCK)
WHERE
    c.Status = 1
    AND c.DateOfBirth IS NOT NULL
    AND (
        (
            MONTH(c.DateOfBirth) = MONTH(DATEADD(DAY, -41, CAST(GETDATE() AS DATE)))
            AND DAY(c.DateOfBirth) = DAY(DATEADD(DAY, -41, CAST(GETDATE() AS DATE)))
        )
        OR
        (
            MONTH(c.DateOfBirth) = 2
            AND DAY(c.DateOfBirth) = 29
            AND MONTH(DATEADD(DAY, -41, CAST(GETDATE() AS DATE))) = 2
            AND DAY(DATEADD(DAY, -41, CAST(GETDATE() AS DATE))) = 28
            AND YEAR(DATEADD(DAY, -41, CAST(GETDATE() AS DATE))) % 4 <> 0
        )
    )
ORDER BY 3 DESC


