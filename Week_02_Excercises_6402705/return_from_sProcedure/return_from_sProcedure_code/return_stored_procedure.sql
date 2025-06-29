-- Drop the table if it exists
DROP TABLE IF EXISTS projects;

-- Create the projects table
CREATE TABLE projects (
    project_id INT PRIMARY KEY,
    project_name VARCHAR(100),
    start_date DATE,
    end_date DATE,
    status VARCHAR(20)
);

-- Insert sample data
INSERT INTO projects (project_id, project_name, start_date, end_date, status) VALUES
(1, 'AI Chatbot', '2024-01-10', '2024-05-15', 'Completed'),
(2, 'E-commerce Website', '2024-03-01', '2024-08-30', 'In Progress'),
(3, 'Inventory System', '2024-06-01', NULL, 'Pending'),
(4, 'Mobile App', '2024-04-20', '2024-09-10', 'In Progress'),
(5, 'Blockchain Pilot', '2024-02-15', '2024-06-30', 'Completed');

DROP PROCEDURE IF EXISTS GetProjectCountByStatus;

CREATE PROCEDURE GetProjectCountByStatus(
    IN proj_status VARCHAR(20),
    OUT total INT
)
BEGIN
    SELECT COUNT(*) INTO total
    FROM projects
    WHERE status = proj_status;
END;

select * from projects;

-- Step 1: Prepare the output variable
SET @count = 0;

-- Step 2: Call the procedure with your input
CALL GetProjectCountByStatus('Completed', @count);

-- Step 3: Show the result
SELECT @count;