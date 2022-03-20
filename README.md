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
* Can create or delete events and paintings available for sale.
* Have access to All Sales and Booking History.
  
<strong> Manager: </strong>
* Can approve the requested cancellation of an order.
* Both admin and manager can Confirm or decline the user's booked event. It depends on Max Capacity for an event.
* Can control what events are available for booking.
  
<strong> :pushpin: Restrictions: </strong>
* Guest Vistors (a user who is not Logged-in) are restricted to browsing through exhibition events and painting in the App Store, also through the Blog Posts, which are available for them to read. Guest Visitors cannot create comments, make orders or book events.
* Users are not allowed to create Blog Posts and Events.
* Any user can create Comments as long as it is a Logged-in user.
* Only admin is allowed to create Blog Posts and Events.
  
</details>

## :hammer: Used technologies
<details>
<summary> 
    Click here for more info. 
 </summary>
  
* ASP.NET CORE 6.0 MVC
* ASP.NET Core areas
* Entity Framework [CORE 6.0](https://docs.microsoft.com/en-us/ef/core/)
* Newtonsoft.Json
* SendGrid
* Cloudinary
* Docker Container
* FontAwesome (font icons)
* HTML5
* CSS
  
</details>

## :floppy_disk: Database Diagram

## Author Name 
Stanislava Stoeva

## License
This project is licensed with the [MIT license](LICENSE).

## Acknowledgments
Using [ASP.NET-MVC-Template](https://github.com/NikolayIT/ASP.NET-MVC-Template) developed by:
- [Nikolay Kostov](https://github.com/NikolayIT)
- [Vladislav Karamfilov](https://github.com/vladislav-karamfilov)
- [Stoyan Shopov](https://github.com/StoyanShopov)

