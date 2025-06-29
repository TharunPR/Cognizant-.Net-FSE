-- Drop the table if it already exists (optional)
DROP TABLE IF EXISTS employees;

-- Step 1: Create the table
CREATE TABLE employees (
    emp_id INT PRIMARY KEY,
    name VARCHAR(50),
    department VARCHAR(50),
    salary INT
);

-- Step 2: Insert sample data
INSERT INTO employees (emp_id, name, department, salary) VALUES
(101, 'Alice', 'HR', 60000),
(102, 'Bob', 'IT', 75000),
(103, 'Charlie', 'IT', 75000),
(104, 'David', 'Sales', 50000),
(105, 'Eve', 'IT', 68000),
(106, 'Frank', 'HR', 60000),
(107, 'Grace', 'Sales', 50000),
(108, 'Helen', 'IT', 68000);

-- Step 3: Rank all employees by salary using RANK()
SELECT emp_id, name, salary,
       RANK() OVER (ORDER BY salary DESC) AS salary_rank
FROM employees;

-- Step 4: Assign row numbers using ROW_NUMBER()
SELECT emp_id, name, salary,
       ROW_NUMBER() OVER (ORDER BY salary DESC) AS row_num
FROM employees;

-- Step 5: Use DENSE_RANK() to rank salaries without gaps
SELECT emp_id, name, salary,
       DENSE_RANK() OVER (ORDER BY salary DESC) AS dense_salary_rank
FROM employees;

-- Step 6: Rank employees by department using PARTITION BY
SELECT emp_id, name, department, salary,
       RANK() OVER (PARTITION BY department ORDER BY salary DESC) AS dept_rank
FROM employees;

-- Step 7: Divide employees into 4 quartiles using NTILE()
SELECT emp_id, name, salary,
       NTILE(4) OVER (ORDER BY salary DESC) AS salary_quartile
FROM employees;
