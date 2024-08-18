# SpeedyAir.ly Flight Scheduling System

This project implements a flight scheduling system for SpeedyAir, a new company providing efficient and fast air freight services. 
The system automates the process of determining which boxes (orders) to load on each flight based on a predefined flight schedule and a list of orders.

## Project Description

The application is a console-based system written in C# that addresses two main user stories:

1. Loading and displaying a flight schedule
2. Generating flight itineraries by scheduling a batch of orders

The system uses a JSON file to load order data and schedules these orders onto available flights based on their destinations.

## Features

- Load and display a predefined flight schedule
- Load orders from a JSON file
- Schedule orders onto available flights
- Display flight itineraries for all orders

## Implementation Details

The project is structured into several classes:

- `Program`: The main entry point of the application
- `Flight`: Represents a flight with its details and associated orders
- `Order`: Represents an order with its details and scheduled flight
- `FlightScheduler`: Manages the scheduling logic and data processing

The implementation follows SOLID principles and employs object-oriented design for maintainability and extensibility.
