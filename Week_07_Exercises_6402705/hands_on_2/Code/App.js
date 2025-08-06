import React from 'react';
import './App.css';

function App() {
  const element = "Office Space";

  const office = {
    Name: "DBS",
    Rent: 50000,
    Address: "Chennai",
    imgSrc: "https://thumbs.dreamstime.com/b/office-work-place-5879959.jpg",
  };

  // Determine rent color
  const rentColorClass = office.Rent <= 60000 ? 'textRed' : 'textGreen';

  return (
    <div className="App">

      {/* Office Display */}
      <div className="office-content">
        <h1>{element}, at Affordable Range</h1>
        <img src={office.imgSrc} width="25%" alt="Office Space" />
        <h1>Name: {office.Name}</h1>
        <h3 className={rentColorClass}>Rent: Rs. {office.Rent}</h3>
        <h3>Address: {office.Address}</h3>
      </div>
    </div>
  );
}

export default App;
