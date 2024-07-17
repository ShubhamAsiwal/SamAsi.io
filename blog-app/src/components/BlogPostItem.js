import React from 'react';
import { Link } from 'react-router-dom';

const BlogPostItem = ({ post, index }) => (
  <div className="card h-100">
    <Link to={`/post/${index}`} className="text-decoration-none text-dark">
      <img src={post.urlToImage} className="card-img-top" alt={post.title} />
      <div className="card-body">
        <h5 className="card-title">{post.title}</h5>
        <p className="card-text">{post.description}</p>
        <p className="card-text">
          <small className="text-muted">{new Date(post.publishedAt).toLocaleDateString()}</small>
        </p>
      </div>
    </Link>
  </div>
);

export default BlogPostItem;
