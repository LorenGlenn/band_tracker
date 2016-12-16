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
