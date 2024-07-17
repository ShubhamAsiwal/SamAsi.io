import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import BlogPostList from './components/BlogPostList';
import BlogPostDetails from './components/BlogPostDetails';
import axios from 'axios';

const App = () => {
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    const fetchPosts = async () => {
      const response = await axios.get(`https://newsapi.org/v2/everything?q=technology&pageSize=10&page=1&apiKey=e358d39fb4374e73b549ad6b7ca3e0f9`);
      setPosts(response.data.articles);
    };
    fetchPosts();
  }, []);

  return (
    <Router>
      <Routes>
        <Route path="/" element={<BlogPostList setPosts={setPosts} />} />
        <Route path="/post/:id" element={<BlogPostDetails posts={posts} />} />
      </Routes>
    </Router>
  );
};

export default App;
