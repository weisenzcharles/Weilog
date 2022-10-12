package org.charles.weilog.service.impl;

import org.charles.weilog.domain.PostMeta;
import org.charles.weilog.repository.PostMetaRepository;
import org.charles.weilog.service.PostMetaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * The type Post meta service.
 */
@Service
public class PostMetaServiceImpl implements PostMetaService {
    private final PostMetaRepository postMetaRepository;

    /**
     * Instantiates a new Post meta service.
     *
     * @param postMetaRepository
     *         the post meta repository
     */
    @Autowired
    public PostMetaServiceImpl(PostMetaRepository postMetaRepository) {
        this.postMetaRepository = postMetaRepository;
    }

    @Override
    public PostMeta insert(PostMeta entity) {
        return postMetaRepository.save(entity);
    }

    @Override
    public void delete(Long id) {
        postMetaRepository.deleteById(id);
    }

    @Override
    public PostMeta update(PostMeta entity) {

        return postMetaRepository.save(entity);
    }

    @Override
    public PostMeta query(Long id) {
        return null;
    }

    @Override
    public List<PostMeta> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<PostMeta> query(int pageIndex, int pageSize) {
        return null;
    }
}