import React, { useState } from 'react';
import './App.css';
import CurrencyConverter from './CurrencyConverter';

function App() {
  const [count, setCount] = useState(0);

  const increment = () => {
    setCount(prev => prev + 1);
    sayHello();
  };

  const sayHello = () => {
    alert("Hello! Counter has been Incremented.");
  };

  const decrement = () => {
    setCount(prev => prev - 1);
    sayHelloDec();
  };
  const sayHelloDec = () => {
    alert("Hello! Counter has been Decremented.");
  };

  const sayWelcome = (message) => {
    alert(message);
  };

  const handleOnPress = () => {
    alert("I was clicked");
  };

  return (
    <div className="App">
      <h1>Event Handling Examples</h1>

      {/* Counter Buttons */}
      <div style={{ marginTop: '10px' }}>
        <h2>Counter: {count}</h2>
        <button onClick={increment}>Increment</button>
      </div>
      {/* Counter Buttons */}
      <div style={{ marginTop: '10px' }}> 
        <button onClick={decrement}>Decrement</button>
      </div>

      {/* Say Welcome Button */}
      <div style={{ marginTop: '10px' }}>
        <button onClick={() => sayWelcome("Welcome!")}>Say Welcome</button>
      </div>

      {/* Synthetic Event */}
      <div style={{ marginTop: '10px' }}>
        <button onClick={handleOnPress}>OnPress Event</button>
      </div>

      {/* Currency Converter Component */}
      <div style={{ marginTop: '20px' }}>
        <CurrencyConverter />
      </div>
    </div>
  );
}

export default App;
