
var map;
var service;
var infowindow;

function initialize() {
  var location = new google.maps.LatLng(7.1475,3.3619);
  console.log(location)

  map = new google.maps.Map(document.getElementById('map'), {
      center: location,
      zoom: 15
    });

  var request = {
    query: document.getElementById("start"),
    fields: ['name', 'geometry'],
  };

   service = new google.maps.places.PlacesService(map);

  service.findPlaceFromQuery(request, function(results, status) {
    if (status === google.maps.places.PlacesServiceStatus.OK) {
      for (var i = 0; i < results.length; i++) {
        createMarker(results[i]);
      }
      map.setCenter(results[0].geometry.location);
    }
  });
}