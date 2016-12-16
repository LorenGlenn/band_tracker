# Band Tracker

#### By **Loren Glenn**

## Description

Can associate and store bands and venues on this site.

#### Specs

| Test                                                             | Input                   | Output         | Description                                                                                                                                 |
|------------------------------------------------------------------|-------------------------|----------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| User is able to insert a new band                                | "Band"                  | Band           | This will be a simple test to see if the band object is created and stored in the database.                                                 |
| User is able to insert a new venue                               | "Venue"                 | Venue          | This will be a simple test to see if the venue object is created and stored in the database.                                                |
| User is able to associate a band with a venue using the venue ID | "Band", "1"             | Venue > Band   | This will be a test to see if the user can add a band to a venue and if it will store the correct ID's in the join table bands_venues       |
| User is able to associate a venue with a band using the band ID  | "Venue", "1"            | Band > Venue   | This will be a test to see if the user can add a venue to a band object and if it will store the correct IDs in the join table bands_venues |
| User can update Venue information                                | "Venue", "new Venue"    | "new Venue"    | This will be a test to see if the data in the database is correctly updated when a user updates a venue                                     |
| User can delete a Venue                                          | click Delete            | ""             | This will be a test to see if the delete method works on the Venue object, making sure it deletes the data from the database                |
| User can associate many bands to a venue                         | "1", "band1", "band2"   | band1, band2   | This will test the get all bands method to see if all associated bands appear when the venue is accessed                                    |
| User can associate many venues to a band                         | "1", "venue1", "venue2" | venue1, venue2 | This will test the get all venues method to see if all associated venues appear when the band is accessed.                                  |


## Setup/Installation Requirements
Update the Startup.cs file as well as the test files to use the correct databases in the connection string variable.
To create the database and tables for this app, connect to your local server and enter the following commands:

In SQLCMD:
> CREATE DATABASE band_tracker;
> GO
> USE band_tracker;
> GO
> CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));
> CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255), city VARCHAR(255));
> CREATE TABLE bands_venues (id INT IDENTITY(1,1), band_id INT, city_id INT);
> GO

Requires Windows and .Net

Clone repository, run ">dnx kestrel" in Powershell and visit "localhost:5004".

## Known Bugs

None.


## Technologies Used

 C# was used for the backend logic as well as routing with Nancy and testing with Xunit. Razor was used to display data on the html pages.

## Support and contact details

 _lorencglenn@gmail.com_

### License

 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 Copyright (c) 2016 **_Loren Glenn_**
