# ArtGallery

## :art: Project Introduction
**Art Gallery** is a Web Application. 
My defense project for **ASP.NET Core** course at Softuni.

## :pencil: Project Description of functionalities
<details>
<summary> 
    Click here for more info. 
</summary>
  
Art Gallery's main idea is to be an app for booking and sales. A place where regular users can book an exhibition or buy a painting. 2 roles: user and admin.
  
<strong> User: </strong>
* Can book an exhibition event in the Gallery or buy a painting from the app store.
* Can read Blog Posts and create comments on any Article.
* Cancel booked exhibition events or request orders cancellation. Once a User cancels, an already made order should be approved by the manager.
  
<strong> Admin: </strong>
* Can Create, Edit or delete FAQ.
* Can Create, Edit or delete Events 
* Can Manage Users, Edit, Roles.
  
<strong> :pushpin: Restrictions: </strong>
* Guest Vistors (a user who is not Logged-in) are restricted to browsing through exhibition events and painting in the App Store, also through the Blog Posts, which are available for them to read.
* Users are not allowed to create FAQ, Events, Blog Posts or new Arts for purchases only if they are Administrators.
* Any user can create Comments, make orders or book events as long as it is a Logged-in user. 
* Only Guest visitors are not allowed to create comments, make orders or book events.
* Only admin is allowed to create Blog Posts, Events or Arts.
  
</details>

## :hammer: Used technologies
<details>
<summary> 
    Click here for more info. 
 </summary>
  
* ASP.NET CORE 6.0 MVC
* ASP.NET Core Areas
* Entity Framework [CORE 6.0](https://docs.microsoft.com/en-us/ef/core/)
* Seeder
* AutoMapper
* Cloudinary
* Docker Container (running Web)
* FontAwesome (font icons)
* HTML5
* CSS
* Two-Factor Authentication
  
</details>

## Test Coverage
<details>
<summary> 
    Click here for more info. 
 </summary>
<img src="https://res.cloudinary.com/dnvg6uuxl/image/upload/v1660657910/app_gallery/test%20coverage/Test_Coverage_Part_1_ipflgg.png" alt="Part1">
<img src="https://res.cloudinary.com/dnvg6uuxl/image/upload/v1660657911/app_gallery/test%20coverage/Test_Coverage_Part_2_wgliji.png" alt="Part2">
<img src="https://res.cloudinary.com/dnvg6uuxl/image/upload/v1660657910/app_gallery/test%20coverage/Test_Coverage_Part_3_pozllh.png" alt="Part3">
<img src="https://res.cloudinary.com/dnvg6uuxl/image/upload/v1660657911/app_gallery/test%20coverage/Test_Coverage_Part_4_se9zim.png" alt="Part4">
</details>

## Resources

* All images are comming from (https://www.rawpixel.com/) & (https://unsplash.com/)
* All Blog Post text were taken from various resources:
   (https://lachri.com/),
   (https://artgallery.co.uk/),
   (https://cassiestephens.blogspot.com/)
   
## Author Name 
Stanislava Stoeva

## License
This project is licensed with the [MIT license](LICENSE).

## Acknowledgments
Created different structure but still Using some file from [ASP.NET-MVC-Template](https://github.com/NikolayIT/ASP.NET-MVC-Template) developed by:
- [Nikolay Kostov](https://github.com/NikolayIT)
- [Vladislav Karamfilov](https://github.com/vladislav-karamfilov)
- [Stoyan Shopov](https://github.com/StoyanShopov)

