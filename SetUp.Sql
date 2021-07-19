USE finale;

-- CREATE TABLE bugProfiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

CREATE TABLE bugs
(
  id INT NOT NULL AUTO_INCREMENT,
  closed TINYINT(1),
  description VARCHAR(255) NOT NULL,
  title VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),

  FOREIGN KEY (creatorId)
  REFERENCES bugProfiles (id)
  ON DELETE CASCADE
);