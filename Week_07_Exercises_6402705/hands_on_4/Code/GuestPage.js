import React from 'react';

function GuestPage({ onLogin }) {
  return (
    <div style={{ textAlign: 'center', marginTop: '100px' }}>
      <h1>Please sign up.</h1>
      <button onClick={onLogin}>Login</button>
    </div>
  );
}

export default GuestPage;
