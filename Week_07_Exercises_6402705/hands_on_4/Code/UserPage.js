import React from 'react';

function UserPage({ onLogout }) {
  return (
    <div style={{ textAlign: 'center', marginTop: '100px' }}>
      <h1>Welcome back!</h1>
      <button onClick={onLogout}>Logout</button>
    </div>
  );
}

export default UserPage;
