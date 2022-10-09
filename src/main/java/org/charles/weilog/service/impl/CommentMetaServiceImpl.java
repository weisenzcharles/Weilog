package org.charles.weilog.service.impl;

import org.charles.weilog.domain.CommentMeta;
import org.charles.weilog.repository.CommentMetaRepository;
import org.charles.weilog.service.CommentMetaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * The type Comment meta service.
 */
@Service
public class CommentMetaServiceImpl implements CommentMetaService {

    private final CommentMetaRepository commentMetaRepository;

    /**
     * Instantiates a new Comment meta service.
     *
     * @param commentMetaRepository the comment meta repository
     */
    @Autowired
    public CommentMetaServiceImpl(CommentMetaRepository commentMetaRepository) {
        this.commentMetaRepository = commentMetaRepository;
    }


    @Override
    public boolean add(CommentMeta commentMeta) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(CommentMeta commentMeta) {
        return false;
    }

    @Override
    public CommentMeta query(Long id) {
        return null;
    }

    @Override
    public List<CommentMeta> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<CommentMeta> query(int pageIndex, int pageSize) {
        return null;
    }
}