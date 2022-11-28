# Property Renting Supplementary Specification

# Introduction
The purpose of this documents is to define requirements of the Property Renting system. This Supplementary Specification lists the requirements that are not readily captured in the use cases of the use-case model. The Supplementary Specification and the use-case model together capture a complete set of requirements on the system. 

# Non-functional Requirements

This Supplementary Specification applies to the Property Renting system which will pe developed by Lorena Dragan, Computer Science student at TUC-N, 3d year. It will consist of the client-server system to interface with an existing users and property ads databses.

The Property Registration Application will enable users to register and search for a place to rent and also the administrators to perform operations on user data and generate reports.

This specification defines the non-functional requirements of the system; such as reliability, usability, performance, and supportability as well as functional requirements that are common across a number of use cases. (The functional requirements are defined in the Use Case Specifications.)

## Availability

The Property Renting System shall be available 24 hours a day, 7 days a week. There shall be no more than 4% down time.  Mean time between Failues shall exceed 300 hours.

## Performance

The system supports one user against the central database at any given time. 

The system shall provide access to the legacy course catalog database with no more than a 10 second latency. 

The system must be able to complete all the transactions within 2 minutes.

## Security

The system offers security through authentication.

## Testability

MSTest from Microsoft integrated in Visual Studio

## Usability

The Proeprty Renting system shall be used by any person who is looking for a new place to rent or to offer for rent a property of his own,

The desktop user-interface will be implemented using WPF. The user interface shall be designed for ease-of-use and shall be appropriate for a marketing community with no additional training on the System.  

# Design Constraints

The system shall integrate with existing databases which operate on Microsoft SQL Server Management Studio. 

The client portion of the application shall operate on any personal computer. 

The data used in the application will be stored in a database, using an ORM (Object Relational Mapping) framework.

To design the application the Model-View-ViewModel pattern shall be used. 

To generate the reports the Factory Method design pattern shall be used. 

# Resources

* http://www.upedu.org/process/gdlines/md_srs.htm
* Example of Supplementary Specification: http://csis.pace.edu/~marchese/SE616_New/Samples/Example%20%20Supplementary%20Specification.htm
