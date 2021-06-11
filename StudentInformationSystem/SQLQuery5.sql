CREATE TABLE StudStatus
(
Id INT PRIMARY KEY,
StatusDescr VARCHAR(100)
);

INSERT INTO StudStatus
(Id, StatusDescr)
VALUES
(1, 'Acitve'),
(2, 'Self-learning'),
(3, 'Absentia'),
(4, 'Interrupted by progress'),
(5, 'Interrupted by illness'),
(6, 'Interrupted by motherhood')