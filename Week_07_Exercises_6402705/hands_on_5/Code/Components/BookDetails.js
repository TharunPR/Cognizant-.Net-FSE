import React from 'react';

const BookDetails = ({ books }) => {
  return (
    <div className='App'>
      {books.map((book) => (
        <div key={book.id}>
          <h3>{book.bname}</h3>
          <p>{book.price}</p>
        </div>
      ))}
    </div>
  );
};

export default BookDetails;
