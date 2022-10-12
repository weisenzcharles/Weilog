package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Tag;
import org.charles.weilog.repository.TagRepository;
import org.charles.weilog.service.TagService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * The type Tag service.
 */
@Service
public class TagServiceImpl implements TagService {

    private final TagRepository tagRepository;

    /**
     * Instantiates a new Tag service.
     *
     * @param tagRepository
     *         the tag repository
     */
    @Autowired
    public TagServiceImpl(TagRepository tagRepository) {
        this.tagRepository = tagRepository;
    }

    @Override
    public Tag insert(Tag entity) {
        return tagRepository.save(entity);
    }

    @Override
    public void delete(Long id) {
        tagRepository.deleteById(id);
    }

    @Override
    public Tag update(Tag entity) {
        return tagRepository.save(entity);
    }

    @Override
    public Tag query(Long id) {
        return null;
    }

    @Override
    public List<Tag> query(String tag) {
        return null;
    }

    @Override
    public List<Tag> query(int pageIndex, int pageSize) {
        return null;
    }
}