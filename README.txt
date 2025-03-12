# Recipe Website

This is an ongoing project for a recipe website where users can search for recipes, view detailed recipe information, and interact with recipes by commenting, rating, and saving their favorites. The project is currently under development, and more features will be added as it progresses.

## Features

### Implemented Features
- **User Registration**: Users can register an account to access additional features.
- **User Login**: Registered users can log in and access their personal area.

### Admin Features (In Progress)
- **Approve Recipes**: Admins can approve pending recipe submissions.
- **Manage Users**: Admins can lock and unlock users (coming soon).
- **Add and Manage Ingredients and Categories**: Admins can add new ingredients, categories, and difficulty levels.

### Features in Progress
- **Add New Recipes**: Users will be able to create and submit new recipes.
- **Comments**: Users will be able to comment on recipes.
- **Rating**: Users will be able to rate recipes based on their experience.
- **Favorites**: Users will be able to add recipes to their favorites for later reference.
- **Manage Favorites**: Users will be able to manage their list of favorite recipes.
- **Search Functionality**: Users can search for recipes based on various fields (e.g., name, ingredients).
- **View Recipe Details**: Users can view detailed information for each recipe.

## Tech Stack

- **Front-end**: Razor Pages (C#), HTML, CSS, JavaScript
- **Back-end**: C# (ASP.NET Core with Razor Pages)
- **Database**: SQL Server
- **Other**: ADO.NET, SQL Client

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/joaossch/Recipie-Project/.git

2.Download and run the database.sql file to set up your SQL Server database.

3.Update the database connection string in
 public string GetDatabaseConnectionString()
 {
     _connectionString = "Data Source=João\\SQLEXPRESS;Initial Catalog=Project Drink;Integrated Security=true";
     
     return _connectionString;
 }
