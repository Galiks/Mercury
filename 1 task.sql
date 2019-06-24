USE Solution2
GO

Select  m.Title
FROM Movie as m
WHERE ReleaseDate <= '20181231 00:00:00.000' AND Rating > 7