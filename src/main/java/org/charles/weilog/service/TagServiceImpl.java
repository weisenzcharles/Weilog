package org.charles.weilog.service;

import org.charles.weilog.domain.Tag;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TagServiceImpl implements TagService {

    @Override
    public boolean add(Tag tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Tag tag) {
        return false;
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
