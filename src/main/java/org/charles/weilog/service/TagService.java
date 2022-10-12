package org.charles.weilog.service;

import org.charles.weilog.domain.Tag;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface TagService {

    Tag insert(Tag entity);

    void delete(Long id);

    Tag update(Tag entity);

    Tag query(Long id);

    List<Tag> query(String tag);

    List<Tag> query(int pageIndex, int pageSize);
}