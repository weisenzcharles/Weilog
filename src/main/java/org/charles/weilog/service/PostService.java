package org.charles.weilog.service;

import org.charles.weilog.domain.Post;

import java.util.List;

public interface PostService {
    public boolean add(Post tag);

    public boolean remove(Long id);

    public boolean update(Post tag);

    public Post query(Long id);

    public List<Post> query(String title, int pageIndex, int pageSize);

    public List<Post> query(int pageIndex, int pageSize);
}
