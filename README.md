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

## Description about my Solution
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

## Description about my approach

## Adjustments

A brief mention on some aspects that either should be present or have been altered for the sake of time or resources.

1.  Icons have been altered, as some of them are part of the "PRO' package of Font Awesome, and thus not available.
2. Material UI has been used as a UI framework to speed up the development process, and keep the design to industry standard.
3. Filtering is done based on the Region and Weather Station. So "Arcen" and "Venlo"  will both show "Meetstation Arcen (Venlo)"
4. Testing has not been performed due to time limitations. However, some tests that could have been performed were unit tests on testing specific components such as the Autocomplete, or displaying of weather data.

Due to the size of the application, this has been simply tested manually by performing actions.

## Authors

* **Noah Scharrenberg** - *Software Developer* - [Noah Scharrenberg](https://github.com/nscharrenberg/)
