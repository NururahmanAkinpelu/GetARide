let getOngoingTripsCount = async () => 
{
  let unCount = await fetch('https://localhost:5001/api/Trip/GetOngoingTripsCount');
  let jsonUnCount = await unCount.json();
  console.log(jsonUnCount); 
  return jsonUnCount;
} 
  
let displayTripCount = async () => 
{
  console.log
  const count =await getOngoingTripsCount()
  console.log(count);
  let display = document.getElementById("ogtrip")
  display.innerHTML += count;
} 
displayTripCount();

