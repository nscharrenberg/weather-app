<br/>
<p align="center">
  <a href="https://github.com/nscharrenberg/weather-app">
    <img src="https://introductie-cases.educom.nu/assets/images/eweather-logo-e008be849d6643601042bd5d80d566bc.png" alt="Logo" width="200" height="80">
  </a>

<h3 align="center">eWeather Frontend</h3>

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
    * [Prerequisites](#prerequisites)
    * [Installation](#installation)
* [Usage](#usage)
* [Adjustments](#adjustments)
* [Authors](#authors)

## About The Project

![Screen Shot](https://github.com/nscharrenberg/weather-app/blob/dev/demo/frontend.png?raw=true)

An easy to use weather application utilizing buienradar.nl to show the dutch local weather information.

## Built With



* [React](https://reactjs.org/)
* [Material UI](https://mui.com/material-ui)
* [Font Awesome](https://fontawesome.com/v6)

## Getting Started

To get a local copy up and running follow these steps.

### Prerequisites

Before being able to run the project, it's expected to have the following prerequisites:
- [Node.js](https://nodejs.org/en/)
- [NPM](https://www.npmjs.com/) ( installed with node.js)
- Git

### Installation

1. Clone the repository

```sh
git clone git@github.com:nscharrenberg/weather-app.git
```

2. Open a terminal on the `frontend` directory.
   for example:
```sh
cd ~/weatherapp/frontend
```

3. Install NPM packages

```sh
npm install
```

4. Start the application

```sh
npm start
```

## Usage

Once the application is running, it should automatically open a browser window and load the application. (`http://localhost:3000` will most likely be the address).

You should see a similar view as shown in "About The Project".

Now click on "Weather Station or City" and search for the city (region) or weather station you want to get information from.

Selecting the weather station option will show its current weather data to you.

Information such as:
- Current Temperature
- Feel Temperature
- Ground Temperature
- Solar Strength
- Rain the past hour
- Wind Direction

## Adjustments

A brief mention on some aspects that either should be present or have been altered for the sake of time or resources.

1.  Icons have been altered, as some of them are part of the "PRO' package of Font Awesome, and thus not available.
2. Material UI has been used as a UI framework to speed up the development process, and keep the design to industry standard.
3. Filtering is done based on the Region and Weather Station. So "Arcen" and "Venlo"  will both show "Meetstation Arcen (Venlo)"
4. Testing has not been performed due to time limitations. However, some tests that could have been performed were unit tests on testing specific components such as the Autocomplete, or displaying of weather data.

Due to the size of the application, this has been simply tested manually by performing actions.

## Authors

* **Noah Scharrenberg** - *Software Developer* - [Noah Scharrenberg](https://github.com/nscharrenberg/) - **