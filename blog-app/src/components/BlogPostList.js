import React, { useState, useEffect } from 'react';
import axios from 'axios';
import BlogPostItem from './BlogPostItem';

const BlogPostList = () => {
  const [posts, setPosts] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [postsPerPage] = useState(5);

  useEffect(() => {
    const fetchPosts = async () => {
      const response = await axios.get('https://newsapi.org/v2/everything?q=tesla&from=2024-06-17&sortBy=publishedAt&apiKey=e358d39fb4374e73b549ad6b7ca3e0f9');
      setPosts(response.data.articles);
    };
    fetchPosts();
  }, []);

  const indexOfLastPost = currentPage * postsPerPage;
  const indexOfFirstPost = indexOfLastPost - postsPerPage;
  const currentPosts = posts.slice(indexOfFirstPost, indexOfLastPost);

  const handleNextPage = () => {
    if (currentPage < Math.ceil(posts.length / postsPerPage)) {
      setCurrentPage(currentPage + 1);
    }
  };

  const handlePrevPage = () => {
    if (currentPage > 1) {
      setCurrentPage(currentPage - 1);
    }
  };

  return (
    <div className="container mt-4">
      <h1 className="mb-4">Blog Posts</h1>
      <div className="row">
        {currentPosts.map((post, index) => (
          <div key={indexOfFirstPost + index} className="col-md-4 mb-4">
            <BlogPostItem post={post} index={indexOfFirstPost + index} />
          </div>
        ))}
      </div>
      <div className="d-flex justify-content-between mt-4">
        <button className="btn btn-primary" onClick={handlePrevPage} disabled={currentPage === 1}>Previous</button>
        <button className="btn btn-primary" onClick={handleNextPage} disabled={currentPage === Math.ceil(posts.length / postsPerPage)}>Next</button>
      </div>
    </div>
  );
};

export default BlogPostList;