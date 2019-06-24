USE Solution2
GO

Select  Count(*) as 'Count of Actors'
FROM Movie as m
JOIN MovieActor as ma ON m.id = ma.MovieId
JOIN Actor as a ON a.id = ma.ActorId
GROUP BY m.Title
HAVING COUNT(m.Title) BETWEEN 3 AND 7