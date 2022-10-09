package org.charles.weilog.service;

import org.charles.weilog.domain.Tag;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface TagService {

    boolean add(Tag tag);

    boolean remove(Long id);

    boolean update(Tag tag);

    Tag query(Long id);

    List<Tag> query(String tag);

    List<Tag> query(int pageIndex, int pageSize);
}