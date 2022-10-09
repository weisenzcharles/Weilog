package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Post;
import org.charles.weilog.domain.Taxonomy;
import org.charles.weilog.repository.PostRepository;
import org.charles.weilog.service.PostService;
import org.charles.weilog.vo.PostQuery;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.stereotype.Service;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;
import java.util.ArrayList;
import java.util.List;


/**
 * The type Post service.
 */
@Service
public class PostServiceImpl implements PostService {

    private final PostRepository postRepository;

    /**
     * Instantiates a new Post service.
     *
     * @param postRepository the post repository
     */
    @Autowired
    public PostServiceImpl(PostRepository postRepository) {
        this.postRepository = postRepository;
    }

    @Override
    public Page<Post> listPost(Pageable pageable) {
        return postRepository.findAll(pageable);
    }

    @Override
    public Page<Post> listPost(Pageable pageable, Post blog) {
        return postRepository.findb;
    }

    @Override
    public Page<Post> listPost(Pageable pageable, PostQuery postQuery) {
        return postRepository.findAll((Specification<Post>) (root, query, criteriaBuilder) -> {
            List<Predicate> Predicates = new ArrayList<>();
            if (!"".equals(postQuery.getTitle()) && postQuery.getTitle() != null) {
                Predicates.add(criteriaBuilder.like(root.<String>get("title"), "%" + postQuery.getTitle() + "%"));
            }
            if (postQuery.getTaxonomyId() != null) {
                Predicates.add(criteriaBuilder.equal(root.<Taxonomy>get("type").get("id"), postQuery.getTaxonomyId()));
            }
            if (postQuery.isRecommend()) {
                Predicates.add(criteriaBuilder.equal(root.<Boolean>get("recommend"), postQuery.isRecommend()));
            }
            query.where(Predicates.toArray(new Predicate[Predicates.size()]));
            return null;
        }, pageable);
    }

    @Override
    public boolean add(Post tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Post tag) {
        return false;
    }

    @Override
    public Post query(Long id) {
        return null;
    }

    @Override
    public List<Post> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Post> query(int pageIndex, int pageSize) {
        return null;
    }
}