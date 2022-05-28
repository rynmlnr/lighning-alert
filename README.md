# Alert Asset Owner on Lightning Strikes
This application reads lightning events data as a stream from standard input (one lightning strike per line as a JSON object,
and matches that data against a source of assets (also in JSON format) to produce an alert to asset owner.

# Technology / Tools:
- VS 2022
- .NET 6.0
- Console Application

# Build & Download the solution
1. Fork or Download the solution (master)
2. Clean and Build the solution
  2.1 Make sure the assets folder with (assets.json and lightning.json) has been created in the debug/.net/ folder
  2.2 If folder not found make sure to copy and paste the assets folder in the debug/.net/
3. Run the application

# Answers

## What is the time complexity for determining if a strike has occurred for a particular asset?
> Big O (n of total registered assets)

## If we put this code into production, but found it too slow, or it needed to scale to many more users or more frequent strikes what are the first things you would think of to speed it up?
> By using the auto-scaling technique that some cloud server is providing, it will increase or decrease number of resources that are being allocated to the 
> systems needs at a given moment in time
