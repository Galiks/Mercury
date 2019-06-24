
----количество фильмов более 60 минут
--Select d.id, d.Name
--FROM Director as d
--JOIN Movie as m ON m.DirectorId = d.id
--Where m.DurationMinutes >= 60 AND m.Rating > 3
--GROUP BY d.id, d.Name
--HAVING COUNT(m.Title) >= 2
----INTERSECT
----количество актёров
--Select d.id, d.Name, m.id
--FROM Movie as m
--JOIN MovieActor as ma ON m.id = ma.MovieId
--JOIN Actor as a ON a.id = ma.ActorId
--JOIN Director as d ON d.id = m.DirectorId
--WHERE m.ReleaseDate <= '20050101 00:00:00.000'
--GROUP BY d.id, d.Name, m.id
--HAVING COUNT(*) Between 3 AND 7


Select  d.Name
FROM Movie as m
JOIN Director as d ON d.id = m.DirectorId
Where m.DurationMinutes >= 60 AND m.Rating > 6
AND m.ReleaseDate <= '20050101 00:00:00.000'
GROUP BY d.Name
HAVING COUNT(m.Title) BETWEEN 3 AND 7

--Select d.id, d.Name
--FROM Director as d
--JOIN Movie as m ON m.DirectorId = d.id
--Where m.DurationMinutes >= 60 AND m.Rating > 6
--GROUP BY d.id, d.Name