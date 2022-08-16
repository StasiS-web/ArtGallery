# ArtGallery

## :art: Project Introduction
**Art Gallery** is a Web Application. 
My defense project for **ASP.NET Core** course at Softuni.

## :pencil: Project Description of functionalities
<details>
<summary> 
    Click here for more info. 
</summary>
  
Art Gallery's main idea is to be an app for booking and sales. A place where regular users can book an exhibition or buy a painting. 3 roles: user, admin and manager.
  
<strong> User: </strong>
* Can book an exhibition event in the Gallery or buy a painting from the app store.
* Can read Blog Posts and create comments on any Article.
* Cancel booked exhibition events or request orders cancellation. Once a User cancels, an already made order should be approved by the manager.
  
<strong> Admin: </strong>
* Can create or delete Blog Posts.
* Can create, update or delete events and paintings available for sale.
* Can Manage Users.
  
<strong> Manager: </strong>
* Can approve the requested cancellation of an order.
* Can Confirm or Decline the user's booked event. It depends on Max Capacity for the event.
* Can control what events are available for booking.
  
<strong> :pushpin: Restrictions: </strong>
* Guest Vistors (a user who is not Logged-in) are restricted to browsing through exhibition events and painting in the App Store, also through the Blog Posts, which are available for them to read.
* Users are not allowed to create Blog Posts, Events or new Arts for purchases only if they are Administrators.
* Any user can create Comments as long as it is a Logged-in user. 
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
  
</details>

## Test Coverage
<img src="https://res.cloudinary.com/dnvg6uuxl/image/upload/v1660657910/app_gallery/test%20coverage/Test_Coverage_Part_1_ipflgg.png" alt="Part1">
<img src="https://res.cloudinary.com/dnvg6uuxl/image/upload/v1660657911/app_gallery/test%20coverage/Test_Coverage_Part_2_wgliji.png" alt="Part2">
<img src="https://res.cloudinary.com/dnvg6uuxl/image/upload/v1660657910/app_gallery/test%20coverage/Test_Coverage_Part_3_pozllh.png" alt="Part3">
<img src="https://res.cloudinary.com/dnvg6uuxl/image/upload/v1660657911/app_gallery/test%20coverage/Test_Coverage_Part_4_se9zim.png" alt="Part4">

## Resources

* All images are comming from (https://www.rawpixel.com/) & (https://unsplash.com/)
* All Blog Post were taken from various resources:
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

