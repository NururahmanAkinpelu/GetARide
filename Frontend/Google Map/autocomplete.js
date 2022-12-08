const center = { lat: 50.064192, lng: -130.605469 };
// Create a bounding box with sides ~10km away from the center point
const defaultBounds = {
  north: center.lat + 0.1,
  south: center.lat - 0.1,
  east: center.lng + 0.1,
  west: center.lng - 0.1,
};
const input = document.getElementById("start");
const options = {
  bounds: defaultBounds,
  componentRestrictions: { country: "nigeria" },
  fields: ["address_components", "geometry", "icon", "name"],
  strictBounds: false,
  types: ["establishment"],
};
const autocomplete = new google.maps.places.Autocomplete(input, options);

autocomplete.setFields(["place_id", "geometry", "name"]);

const southwest = { lat: 7.1475, lng: 3.3619 };
const newBounds = new google.maps.LatLngBounds(southwest);

autocomplete.setBounds(newBounds);
autocomplete.bindTo("bounds", map);