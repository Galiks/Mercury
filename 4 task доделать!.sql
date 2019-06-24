USE Solution2
GO

Select  d.Name
FROM Movie as m
JOIN MovieActor as ma ON m.id = ma.MovieId
JOIN Director as d ON d.id = m.DirectorId
Where m.DurationMinutes >= 60 AND m.Rating > 8
AND m.ReleaseDate <= '20050101 00:00:00.000'
GROUP BY d.Name, m.Title
HAVING COUNT(m.Title) BETWEEN 3 AND 7