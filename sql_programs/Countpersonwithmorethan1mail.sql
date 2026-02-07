select e.name,e.email from employees e
where e.email in(select email from employees
group by email
having count(*)>1)
