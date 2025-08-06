import React, { useState } from 'react';

function CurrencyConverter() {
  const [amount, setAmount] = useState('');
  const [converted, setConverted] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    const rate = 0.011; // Example conversion rate: 1 INR = 0.011 Euro
    const euroValue = parseFloat(amount) * rate;

    if (isNaN(euroValue)) {
      alert("Please enter a valid number");
      return;
    }

    setConverted(euroValue.toFixed(2));
  };

  return (
    <div>
      <h2 style={{ color: 'green' }}>Currency Convertor!!!</h2>
      <form onSubmit={handleSubmit}>
        <label>Amount: </label>
        <input
          type="text"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
        />
        <br /><br />
        <label>Currency: </label>
        <input type="text" value="Euro" disabled />
        <br /><br />
        <button type="submit">Submit</button>
      </form>

      {converted && (
        <h3>Converted Amount: € {converted}</h3>
      )}
    </div>
  );
}

export default CurrencyConverter;
