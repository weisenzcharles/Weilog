package org.charles.weilog.service;

import org.charles.weilog.domain.Tag;

import java.util.List;


public interface TagService {

    public boolean add(Tag tag);

    public boolean remove(Long id);

    public boolean update(Tag tag);

    public Tag query(Long id);

    public List<Tag> query(String tag);

    public List<Tag> query(int pageIndex, int pageSize);
}
