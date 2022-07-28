<br/>
<p align="center">
  <a href="https://github.com/nscharrenberg/weather-app">
    <img src="https://introductie-cases.educom.nu/assets/images/eweather-logo-e008be849d6643601042bd5d80d566bc.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">eWeather App</h3>

  <p align="center">
    Quickly watch the dutch weather
    <br/>
    <br/>
    <a href="https://github.com/nscharrenberg/weather-app">View Demo</a>
    .
  </p>
</p>



## Table Of Contents

* [About the Project](#about-the-project)
* [Built With](#built-with)
* [Getting Started](#getting-started)
* [Adjustments](#adjustments)
* [Authors](#authors)

## About The Project

![Screen Shot](https://github.com/nscharrenberg/weather-app/blob/dev/demo/frontend.png?raw=true)

An easy to use weather application utilizing buienradar.nl to show the dutch local weather information.

## Built With
* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
* [React](https://reactjs.org/)
* [Material UI](https://mui.com/material-ui)
* [Font Awesome](https://fontawesome.com/v6)
* [Recharts](https://recharts.org/)
* [Buienradar](https://www.buienradar.nl/)

## Getting Started

The Getting Started Guide for the frontend App is explained in the `frontend` directory.

The Getting Started Guide for the backend App is explained in the `backend` directory.

## Description about my Solution & Approach
### Frontend
The frontend is made using React with the Material UI Framework, for its easiness in development, quick setup and standardized design.

The general structure of the frontend application is as follows:
- src
  - components -> Contains single decoupled components
  - router -> Contains the page routes
  - services -> Contains the service logic such as API calls
  - store -> Contains local memory structure (state)
  - views -> Contains the page views

**Components** contains single decoupled components that can be used in pages. Think about the Searchbar, Graph, Temperature Information, and so on.

**Router** contains the page routes, in the end it was only one page that was being used, so this router wouldn't have been necessary.

**Services** contains the API logic to the backend server, making the calls that are necessary.

**Store** contains all the local memory. As it's a small app, only one state module is necessary, which is `weather`. This contains the necessary information the frontend app needs, such as all the stations with their measurements, the selected station (of which we want to see the information), filters, and measurements from the filters.

**views** contains the page views. As it's a small application only one page is present. 

#### Main Flow of the Application
The `SearchBar` will call the necessary `services` for weather information of all the stations and store them in the `store` as `stations`.
When the `value` of `SearchBar` is changed (so a station is selected), it will store this `value` to the `store` as `selectedStation`.

The `WeatherInfo` will listen for changes to `selectedStation` and show waether information using `WeatherCard` replications with data such as temperature, sun power, Ground Temperature, and so on.

The user could alternatively also get an overview of the data over a certain timespan of measurements, which the `DateTimeRangePicker` handles. Here the `EndDate` can not be before the `StartDate` and is limited as such in the users selection process. 
Once the user has made its range selection, it has to press the `Filter` button, to which the `service` will be called again and its value will be stored in the `store` as `overview`.
The `GraphOverview` will listen for changes to `overview` and show the data appropriately in a graph.

### Backend
The backend is made using ASP.NET Core.

For the sake of showcasing how I'd work with bigger applications, I've stuck put to such structures. Even though this application is extremely small, and would therefore not really benefit for it besides adding structural complexity.

The backend is split into three projects:
- API -> Contains the Api Specific Logic
  - Controllers -> The Api Controllers
  - Profiles -> ViewModel System that AutoMapper Uses to map Models with ViewModels.
  - Queries -> Request Parameters the Controller methods use
  - Tasks -> Recurring tasks that run in the background
  - ViewModels -> The Viewmodels that are outputted by the Controllers
- Data -> A Class Library which contains the Entity Framework specific Logic such as migrations and Repository Logic.
  - Migrations -> The migrations that are used to populate the database
  - Repositories -> The EntityFramework specific business logic
- Domain -> A Class Library which contains the domain logic such as models and interfaces.
  - Interfaces -> The standardized Interfaces

The Api Url of buienradar and frequency at which we want to call it are specified in the `appsettings.json` on the `API` project.
This is also where the database is specified (Sql Server for this app)

The `API` exposes two routes, namely:
- `GetAllStations` - `/api/Stations`
- `GetStationByStationId` - `/api/stations/{stationId}`

`GetAllStations` simply retrieves all `Station` records from the database and outputs them as json.

`GetStationByStationId` uses the buienradar defined `stationid` to search the correct `stationId` from the application.
Additionally two query parameters can be passed along for this route. These are `Start` and `End` which indicate the start date and end date of which the user wants to search the Station Weather Measurements.

### How did I deal with certain problems?
#### Cyclic Json References
As Both `Measurement` and `Station` know about each other, when outputting `Station` with `Measurement` the controller would cause the output to go into an infinite loop, due to the fact that Station has Measurement and Measurement has Station (and so on). This issue can be resolved by the ViewModel principle, to which Model data is manipulated into a ViewModel.

I knew from Java that there are tools such as `ModelMapper` that handle most difficult operations for such tasks, and that .NET Core would most likely have something similar. After a quick searhc I came across `AutoMapper` as one of the more popular approaches on using ViewModels. [docs](https://docs.automapper.org/en/stable/Getting-started.html)

#### Background Services
The second issue I had was using a non-singleton object (IUnitOfWork) in to a Singleton instance (WeatherMeasuringService).
This service calls the buienradar API every X seconds and updates its own system with the data.

Here I quickly noticed that ASP.NET Core did not like the DI that was happening on the IUnitOfWork instance, and after some searching I came across a stackoverflow page which mentioned that fact that a scope with the required service should be instantiated, instead of using the usual DI approach, by passing `IServiceScopeFactory` and creating the IUnitWork as a scope for that factory, instead of just passing `IUnitOfWork`.

## Adjustments

A brief mention on some aspects that either should be present or have been altered for the sake of time or resources.

1.  Icons have been altered, as some of them are part of the "PRO' package of Font Awesome, and thus not available.
2. Material UI has been used as a UI framework to speed up the development process, and keep the design to industry standard.
3. Filtering is done based on the Region and Weather Station. So "Arcen" and "Venlo"  will both show "Meetstation Arcen (Venlo)"
4. Testing has not been performed due to time limitations. However, some tests that could have been performed were unit tests on testing specific components such as the Autocomplete, or displaying of weather data.
5. I've kept the exception handling to the bare minimum. I'd generally make sure exceptions are dealt with appropriately.

Due to the size of the application, this has been simply tested manually by performing actions.

## Authors

* **Noah Scharrenberg** - *Software Developer* - [Noah Scharrenberg](https://github.com/nscharrenberg/)
