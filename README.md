# Blazor WebShop with CMS

## Information

This is an example project showcasing some of the features of Blazor WebAssembly. The project includes a Blazor WebShop, a Blazor CMS, and a REST API connecting both of them.

# Table of Contents
1. [Blazor WebShop with CMS](#blazor-webshop-with-cms)
   - [Information](#information)
     - [Blazor WebShop](#blazor-webshop)
       - [Main Features](#main-features)
     - [Blazor CMS](#blazor-cms)
     - [API](#api)
   - [How to run it](#how-to-run-it)
   - [Live Version](#live-version)

### Blazor WebShop

The Blazor WebShop is based on the Electro-template, which can be viewed [here](https://www.templateshub.net/template/Electro-eCommerce-Website-Templates). The project is a Blazor WebAssembly and serves as an example of a computer components shop.

#### Main Features

- Shopping Cart
- Wishlist
- Currency Conversion
- Product Search and Filtering
- User Information Editing
- Order Viewing and PDF Invoice Generation
- Stripe Payment Implementation

### Blazor CMS

The CMS is created using the MudBlazor component library, which can be checked out [here](https://mudblazor.com/). The project is a Blazor WebAssembly.

### API

The API is a basic REST API with controllers implementing the onion architecture.

## How to run it

First you need to fill **appsettings.json**, or respective environment settings files in API project. Here is an example:

```javascript
{
  "ConnectionStrings": {
    "DefaultConnection": "Your database string"
  },
  "JwtConfiguration": {
    "Secret": "your secret string",
    "ValidIssuer": "https://localhost:5000",
    "ValidAudience": "Audience",
    "AccessTokenExpiration": 72,
    "RefreshTokenExpiration": 96
  },
  "Configuration": {
    "FilePathConfiguration": {
      "Image": "/image/",
      "Document": "/document/"
    },
    "Stripe": {
      "PubKey": "Stripe Publishable key",
      "SecretKey": "Stripe Secret key"
    },
    "BaseUrls": {
      "WebShop": "https://localhost:7061/"
    },
    "Origins": [ "https://localhost:7061" ]
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
You will also need to create database you can use Entity Framework migrations to do so, but I also provided database creation script including some dummy data. If you're going to use my dummy data, make sure to also copy the image folder to the wwwroot of the API project. Both are in the [GithubFiles folder](GithubFiles)

## Live Version - Not working currently

~~If you want to check the hosted version, it is available online at https://webshop.myexzzy.uk/. Feel free to test the features including the payment system (you can use [test cards](https://stripe.com/docs/testing) from Stripe). Everything should work as expected~~

~~For registered users, there is no need for email activation after registration. Everything works as an anonymous user, except you will not have access to user information and orders. If you want to use existing user, you can use the following credentials:~~

    Email: lukeBenson@rhyta.com
    Password: ei4DU8FdGpmHuXi

**Important**

The website is hosted on my home server and includes the database, API, and Blazor project, so it may be slow due to my internet connection.

For those interested in the setup, it uses NGINX for the API and Blazor project, and everything is served to the internet using Cloudflare tunnel.
