import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';

const BlogPostDetails = ({ posts }) => {
const { id } = useParams();
const navigate = useNavigate();
const post = posts[parseInt(id, 10)];

if (!post) {
    return <div className="container mt-4">Post not found</div>;
}

  return (
    <div className="container mt-4">
      <button className="btn btn-secondary mb-4" onClick={() => navigate(-1)}>Back</button>
      <div className="card">
        <img src={post.urlToImage} className="card-img-top" alt={post.title} />
        <div className="card-body">
          <h1 className="card-title">{post.title}</h1>
          <p className="card-text">{post.content}</p>
          <p className="card-text">
            <small className="text-muted">{new Date(post.publishedAt).toLocaleDateString()}</small>
          </p>
        </div>
      </div>
    </div>
  );
};

export default BlogPostDetails;
