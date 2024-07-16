--drop database office;

--create database office;

create table post (id serial primary key, description text, salary float);

create table users(id serial primary key,FIO varchar(255), postId int, datebirth timestamp, datestart timestamp, 
telegramId integer, password text);

create table holiday (id serial primary key, dateStart timestamp, dateEnd timestamp, dateCreate timestamp, 
dateApp timestamp, isAppAdmin boolean, isAppDirect boolean, userId integer, isPay boolean);

create table dayoff (id serial primary key, date timestamp, dateCreate timestamp, dateApp timestamp, 
isApp boolean, userId integer);

create table medical (id serial primary key, userid int, dateStart timestamp, dateEnd timestamp, 
dateCreate timestamp);

create table task(id serial primary key, key varchar(50), time float, userid int, date timestamp);

create view availabledays as 

select u.fio, date_part('month', age(u.datestart))*2.33 - 
	sum(ras.res) as dates
from users as u
join holiday as h on h.userId = u.id
join (select date_part('day', age(dateStart, dateEnd)) as res, userId from holiday) as 
ras on ras.userId = u.id
group by u.fio, u.datestart;


alter table users 
    add constraint fk_post_user
    foreign key (postId) 
    REFERENCES post (id);


alter table holiday 
    add constraint fk_holiday_user
    foreign key (userId) 
    REFERENCES users (id);

alter table dayoff 
    add constraint fk_dayoff_user
    foreign key (userId) 
    REFERENCES users (id);
    
alter table medical 
    add constraint fk_medical_user
    foreign key (userId) 
    REFERENCES users (id);
    
alter table task 
    add constraint fk_task_user
    foreign key (userId) 
    REFERENCES users (id);