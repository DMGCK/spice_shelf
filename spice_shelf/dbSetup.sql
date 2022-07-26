CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT AUTO_INCREMENT PRIMARY KEY,
        picture TEXT COMMENT 'IMGURL',
        title VARCHAR(255) COMMENT 'Title' NOT NULL,
        subtitle VARCHAR(255) COMMENT 'Subtitle',
        category VARCHAR(255) COMMENT 'category',
        creatorId VARCHAR(255) COMMENT 'creatorId' NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT AUTO_INCREMENT PRIMARY KEY,
        Name VARCHAR(255) COMMENT 'name' NOT NULL,
        quantity int COMMENT 'quantity',
        recipeId int COMMENT 'recipeId' NOT NULL,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS step(
        position int COMMENT 'position',
        body VARCHAR(255) COMMENT 'body' NOT NULL,
        recipeId int COMMENT 'recipeId' NOT NULL,
        FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

/* CREATE TABLE
 IF NOT EXISTS favorite(
 accountId VARCHAR(255) NOT NULL,
 recipeId int COMMENT 'recipeId' NOT NULL,
 FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE FOREIGN key (accountId) REFERENCES accounts(id) on delete CASCADE
 ) default charset utf8 COMMENT ''; */

SELECT recipe.*, acc.*
FROM recipes recipe
    JOIN accounts acc ON recipe.creatorId = acc.id