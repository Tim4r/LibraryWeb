INSERT INTO Authors (FirstName, LastName, BirthDate, Country)
VALUES 
('J.K.', 'Rowling', '1965-07-31', 'United Kingdom'),
('George R.R.', 'Martin', '1948-09-20', 'United States'),
('Stephen', 'King', '1953-09-21', 'United States'),
('J.R.R.', 'Tolkien', '1892-01-03', 'United Kingdom'),
('Harper', 'Lee', '1926-04-28', 'United States'),
('Jane', 'Austen', '1775-12-16', 'England'),
('Charles', 'Dickens', '1812-02-07', 'England'),
('Leo', 'Tolstoy', '1828-08-09', 'Russia'),
('Virginia', 'Woolf', '1882-01-25', 'England'),
('Gabriel', 'Ansley', '1990-05-15', 'Canada'),
('Zadie', 'Smith', '1975-10-25', 'United Kingdom'),
('Don', 'DeLillo', '1936-11-20', 'United States'),
('Margaret', 'Atwood', '1939-11-18', 'Canada'),
('Kazuo', 'Ishiguro', '1954-11-08', 'Japan/United Kingdom'),
('Alice', 'Munro', '1931-07-10', 'Canada'),
('Salman', 'Rushdie', '1947-06-19', 'India/United Kingdom'),
('Orhan', 'Pamuk', '1952-06-13', 'Turkey'),
('Ngugi wa', 'Thiong o', '1938-01-05', 'Kenya'),
('Miguel Angel', 'Asturias', '1899-10-19', 'Guatemala');


INSERT INTO Categories (Genre)
VALUES 
('Fantasy'),
('Science Fiction'),
('Literary Fiction'),
('Historical Fiction'),
('Horror'),
('Romantic Comedy'),
('Crime Fiction'),
('Philosophical Fiction'),
('Magical Realism'),
('Postmodern Literature'),
('Epistolary Novel'),
('Cyberpunk'),
('Surrealist Fiction'),
('Environmental Fiction'),
('Absurdism');


INSERT INTO Users (Login, PasswordHash, PasswordSalt, Email)
VALUES 
('timanders', '$4b$12$eKCMOqOBkWQrVzRtUyYxuC', '$2b$21$eJnMOqXNkWQrVzRtOyYxuQ', 'timanders@gmail.com'),
('janedoe', '$3b$20$eJCMLqXNkWQrVzRtUyYxuD', '$2b$12$eJCMOqBNkWQrVzRtUyYxuF', 'jane@gmail.com'),
('michaeljordan', '$2b$12$eJCMOqXNkWQrVzRtUyYxuF', '$2b$21$eJnMOqiNkWQrVzRtUyYxuQ', 'mj@gmail.com'),
('emmataylor', '$2b$14$eJCMOQxNkWQrVzRtUyYxuO', '$2b$14$eJCMOQxNkWQrVzRtUyYxuO', 'emma@yahoo.com'),
('davidlee', '$2b$21$eJnMOqXNkWQrVzRtUyYxuQ', '$2b$12$eBCbOqXjkWQrVzRtUyYxuF', 'david@hotmail.com');


INSERT INTO Books (Title, ISBN, Description, Image, AuthorId, CategoryId)
VALUES 
('Harry Potter and the Philosopher''s Stone', '9780747532699', 'The first book in J.K. Rowling''s beloved Harry Potter series.', NULL, 1, 1),
('A Game of Thrones', '9780553573404', 'The first book in George R.R. Martin''s A Song of Ice and Fire series.', NULL, 2, 1),
('Misery', '9780743454651', 'A psychological horror novel by Stephen King about a writer held captive by his ''number one fan''.', NULL, 3, 5),
('The Lord of the Rings', '9780261103301', 'High fantasy adventure novel by J.R.R. Tolkien.', NULL, 4, 1),
('To Kill a Mockingbird', '9780061120084', 'Classic novel exploring racial injustice through the eyes of a young girl in the Deep South.', NULL, 5, 2),
('Pride and Prejudice', '9780743273565', 'Romantic novel of manners by Jane Austen.', NULL, 6, 2),
('Oliver Twist', '9780743274562', 'Classic Victorian-era novel about a poor orphan who falls in with a gang of pickpockets in London.', NULL, 7, 3),
('War and Peace', '9780743273565', 'Epic historical novel by Leo Tolstoy set during the Napoleonic Wars.', NULL, 8, 3),
('Mrs Dalloway', '9780241954719', 'Modernist novel by Virginia Woolf exploring life in post-World War I England.', NULL, 9, 2),
('The Brief Wondrous Life of Oscar Wao', '9780374158177', 'Modern magical realist novel by Gabriel Ansley about Dominican-American identity.', NULL, 10, 6),
('White Teeth', '9780312421135', 'Satirical novel by Zadie Smith exploring multiculturalism in post-war London.', NULL, 11, 2),
('Underworld', '9780679767877', 'Postmodern epic novel by Don DeLillo spanning several decades of American history.', NULL, 12, 4),
('The Handmaid''s Tale', '9780553283685', 'Dystopian novel by Margaret Atwood exploring a patriarchal society.', NULL, 13, 1),
('Never Let Me Go', '9780099500736', 'Haunting novel by Kazuo Ishiguro exploring the lives of three friends at an English boarding school.', NULL, 14, 2),
('Half-Blood Prince', '9780439708180', 'Sixth book in the Harry Potter series by J.K. Rowling.', NULL, 1, 1),
('The God of Small Things', '9781782115514', 'Novel by Arundhati Roy exploring the intertwined lives of twins growing up in Kerala, India.', NULL, 15, 2),
('The Namesake', '9781400033416', 'Novel by Jhumpa Lahiri exploring the experiences of Indian immigrants in New York City.', NULL, 16, 2),
('Beloved', '9780743273565', 'Haunting novel by Toni Morrison exploring the legacy of slavery and its effects on African Americans.', NULL, 17, 5),
('The Kite Runner', '9780747584585', 'Novel by Khaled Hosseini exploring friendship, betrayal, and redemption in Afghanistan.', NULL, 18, 2),
('The Road', '9780307276750', 'Post-apocalyptic novel by Cormac McCarthy exploring a father-son journey through a devastated America.', NULL, 19, 4),
('The Remains of the Day', '9780399159926', 'Novel by Kazuo Ishiguro exploring the life of a butler reflecting on his decades-long service at an English estate.', NULL, 14, 2),
('The Brief History of the Dead', '9781594200705', 'Novel by Kevin Brockmeier exploring an afterlife where souls exist in a vast library.', NULL, 19, 4);


INSERT INTO BookLoans (TakenTime, ReturnTime, UserId, BookId)
VALUES 
('2023-01-01', '2023-01-15', 1, 3),
('2023-01-02', '2023-01-16', 4, 4),
('2023-01-03', '2023-01-17', 3, 5),
('2023-01-04', '2023-01-18', 1, 11),
('2023-01-05', '2023-01-19', 2, 8),
('2023-01-06', '2023-01-20', 4, 10),
('2023-01-07', '2023-01-21', 5, 21),
('2023-01-08', '2023-01-22', 2, 15),
('2023-01-09', '2023-01-23', 5, 16),
('2023-01-10', '2023-01-24', 1, 22);
