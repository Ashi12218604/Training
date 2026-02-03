select e.dept,e.name,e.salary
from employees e
where e.salary=(select max(salary) from employees
where e.dept=dept)
