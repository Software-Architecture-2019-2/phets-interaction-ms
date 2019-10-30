-- \connect
-- interaction_db

create table interactions
(
    id_match serial PRIMARY KEY,
    id_main INT NOT NULL,
    id_secondary INT NOT NULL,
    match_1 BOOLEAN NOT NULL,
    match_2 BOOLEAN
);
-- create table matches (id_match PRIMARY KEY, id_animal_main INT NOT NULL, id_animal_secondary INT NOT NULL, match_state BOOLEAN NOT NULL);

ALTER TABLE Interactions OWNER TO phets_interaction;
-- Insert into Interactions(id_main, id_secondary, match_1, match_2) values(1,2,false, NULL);
-- Insert into Interactions(id_main, id_secondary, match_1, match_2) values(2,4,false, NULL);
-- Insert into Interactions(id_main, id_secondary, match_1, match_2) values(2,3,true, NULL);
-- Insert into Interactions(id_main, id_secondary, match_1, match_2) values(1,3,false, NULL);