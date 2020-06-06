# Project Title

This project is an intro to Twilio project. It contains an ASP.NET Core Blazor and a Web API project 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

To run this application, you need to do the following:

1. Install Visual Studio, Visual Studio Code or the .NET CLI. If using Visual Studio Code, install the C# extension. This repo was created with Visual Studio Code.
2. Create a Twilio Account to replace your Account SID and Auth Token by visiting [this link](https://www.twilio.com/try-twilio)
3. Purchase a Twilio phone number by visiting [this link](https://www.twilio.com/console/phone-numbers/incoming)

### Installing

To run this application, do the following:

1. Clone the repo
2. Update Twilio account settings in the user secrets by running the following commands:
```
dotnet user-secrets init
dotnet user-secrets set "Values:Twilio:AccountSid" "<REPLACE_TWILIO_ACCOUNT_SID_HERE>"
dotnet user-secrets set "Values:Twilio:AuthToken" "<REPLACE_TWILIO_AuthToken_HERE>"
dotnet user-secrets set "Values:Twilio:PhoneNumber" "<REPLACE_TWILIO_PHONENUMBER_HERE>"
```
3. Run the application by typing `dotnet run` in the terminal 

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [ASP.NET Core Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - The web framework used
* [Twilio](https://www.twilio.com/) - Twilio

## Authors

* **Corey Weathers** - *Initial work* - [clw895](https://github.com/clw895)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
