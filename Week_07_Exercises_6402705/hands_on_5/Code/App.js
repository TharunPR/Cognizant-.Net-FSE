import React from 'react';
import './App.css';
import BookDetails from './Components/BookDetails';
import BlogDetails from './Components/BlogDetails';
import CourseDetails from './Components/CourseDetails';

function App() {
  const books = [
    { id: 101, bname: 'Master React', price: 670 },
    { id: 102, bname: 'Deep Dive into Angular 11', price: 800 },
    { id: 103, bname: 'Mongo Essentials', price: 450 },
  ];

  const blogs = [
    {
      title: 'React Learning',
      author: 'Stephen Biz',
      description: 'Welcome to learning React!',
    },
    {
      title: 'Installation',
      author: 'Schwezdenier',
      description: 'You can install React from npm.',
    },
  ];

  const courses = [
    { name: 'Angular', date: '4/5/2021' },
    { name: 'React', date: '6/3/2020' },
  ];

  return (
    <div className="container">
      <div className="section">
        <h1>Course Details</h1>
        <CourseDetails courses={courses} />
      </div>

      <div className="section">
        <h1>Book Details</h1>
        <BookDetails books={books} />
      </div>

      <div className="section">
        <h1>Blog Details</h1>
        <BlogDetails blogs={blogs} />
      </div>
    </div>
  );
}

export default App;
