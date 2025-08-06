import React from 'react';

const BlogDetails = ({ blogs }) => {
  return (
    <div className='App'>
      {blogs.map((blog, index) => (
        <div key={index}>
          <h2>{blog.title}</h2>
          <h4>{blog.author}</h4>
          <p>{blog.description}</p>
        </div>
      ))}
    </div>
  );
};

export default BlogDetails;
