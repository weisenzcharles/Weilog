package org.charles.weilog.service;

import org.charles.weilog.domain.Post;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PostServiceImpl implements PostService {
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
