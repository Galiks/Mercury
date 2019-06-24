USE Solution2
GO

Select a.Name, a.Age
FROM Movie as m
JOIN MovieActor as ma ON m.id = ma.MovieId
JOIN Actor as a ON a.id = ma.ActorId
WHERE m.Rating >= 9
ORDER BY a.Name ASC, a.Age DESC