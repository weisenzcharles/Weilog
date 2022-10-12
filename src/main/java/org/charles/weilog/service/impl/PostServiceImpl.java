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
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Service;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;
import java.util.*;


/**
 * The type Post service.
 */
@Service
public class PostServiceImpl implements PostService {

    private final PostRepository postRepository;

    /**
     * Instantiates a new Post service.
     *
     * @param postRepository
     *         the post repository
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
        // return postRepository.findByQuery(pageable,blog);
        return null;
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
            query.where(Predicates.toArray(new Predicate[0]));
            return null;
        }, pageable);
    }

    @Override
    public Post findByAlias(String alias) {
        return postRepository.findByAlias(alias);
    }


    @Override
    public Post insert(Post entity) {
        return postRepository.save(entity);
    }

    @Override
    public void delete(Long id) {
        postRepository.deleteById(id);
    }

    @Override
    public Post update(Post entity) {
        return postRepository.save(entity);
    }

    @Override
    public List<Post> findListByYear(String year) {
        return postRepository.findListByYear(year);
    }

    @Override
    public Map<String, List<Post>> archivePosts() {
        List<String> years = postRepository.findGroupYear();
        Map<String, List<Post>> map = new HashMap<>();
        for (String year : years) {
            map.put(year, postRepository.findListByYear(year));
        }
        return map;
    }

    @Override
    public Post findById(Long id) {
        Optional<Post> result = postRepository.findById(id);
        return result.orElse(null);
    }

    @Override
    public List<Post> findByPaging(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Post> findByPaging(int pageIndex, int pageSize) {
        return null;
    }
}